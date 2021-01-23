	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	// Our stuff
	using System.Text.Json;
        public class FathersData
        {
            public Father[] fathers { get; set; }
        }
        public class Someone
        {
            public string name { get; set; }
        }
        public class Father : Someone
        {
            public int id { get; set; }
            public bool married { get; set; }
            // Lists...
            public List<Son> sons { get; set; }
            // ... or arrays for collections, that's fine:
            public Daughter[] daughters { get; set; }
        }
        public class Child : Someone
        {
            public int age { get; set; }
        }
        public class Son : Child
        {
        }
        public class Daughter : Child
        {
            public string maidenName { get; set; }
        }
	//...
        static void FilteredFatherStreamTestSimplified()
        {
            // Get our parser:
            var parser = new JsonParser();
            // (Note this will be invoked thanks to the "filters" dictionary below)
            Func<object, object> filteredFatherStreamCallback = obj =>
            {
                Father father = (obj as Father);
                // Output only the individual fathers that the filters decided to keep (i.e., when obj.Type equals typeof(Father)),
                // but don't output (even once) the resulting array (i.e., when obj.Type equals typeof(Father[])):
                if (father != null)
                {
                    Console.WriteLine("\t\tId : {0}\t\tName : {1}", father.id, father.name);
                }
                // Do not project the filtered data in any specific way otherwise,
                // just return it deserialized as-is:
                return obj;
            };
            // Prepare our filters, and thus:
            // 1) we want only the last five (5) fathers (array index in the resulting "Father[]" >= 29,995),
            // (assuming we somehow have prior knowledge that the total count is 30,000)
            // and for each of them,
            // 2) we're only interested in obtaining their "id" and "name" properties
            var filters = 
                new Dictionary<Type, Func<Type, object, object, int, Func<object, object>>>
                {
                    // We don't care about anything but these 2 properties:
                    {
                        typeof(Father), // Note the type
                        (type, obj, key, index) =>
                            ((key as string) == "id" || (key as string) == "name") ?
                            filteredFatherStreamCallback :
                            JsonParser.Skip
                    },
                    // We want to pick only the last 5 fathers from the source:
                    {
                        typeof(Father[]), // Note the type
                        (type, obj, key, index) =>
                            (index >= 29995) ?
                            filteredFatherStreamCallback :
                            JsonParser.Skip
                    }
                };
            // Read, parse, and deserialize fathers.json.txt in a streamed fashion,
            // and using the above filters, along with the callback we've set up:
            using (var reader = new System.IO.StreamReader(FATHERS_TEST_FILE_PATH))
            {
                FathersData data = parser.Parse<FathersData>(reader, filters);
                System.Diagnostics.Debug.Assert
                (
                    (data != null) &&
                    (data.fathers != null) &&
                    (data.fathers.Length == 5)
                );
                foreach (var i in Enumerable.Range(29995, 5))
                    System.Diagnostics.Debug.Assert
                    (
                        (data.fathers[i - 29995].id == i) &&
                        !String.IsNullOrEmpty(data.fathers[i - 29995].name)
                    );
            }
            Console.ReadKey();
        }
        // This test deserializes the first ten (10) fathers found in fathers.json.txt,
        // and performs a fixup of the maiden names (all absent from fathers.json.txt)
        // of their daughters (if any):
        static void FilteredFatherStreamTestDaughterMaidenNamesFixup()
        {
            // Get our parser:
            var parser = new JsonParser();
            // (Note this will be invoked thanks to the "filters" dictionary below)
            Func<object, object> filteredFatherStreamCallback = obj =>
            {
                Father father = (obj as Father);
                // Processes only the individual fathers that the filters decided to keep
                // (i.e., iff obj.Type equals typeof(Father))
                if (father != null)
                {
                    if ((father.daughters != null) && (father.daughters.Length > 0))
                        // The fixup of the maiden names is done in-place, on
                        // by-then freshly deserialized father's daughters:
                        foreach (var daughter in father.daughters)
                            daughter.maidenName = father.name.Substring(father.name.IndexOf(' ') + 1);
                }
                // Do not project the filtered data in any specific way otherwise,
                // just return it deserialized as-is:
                return obj;
            };
            // Prepare our filters, i.e., we want only the first ten (10) fathers
            // (array index in the resulting "Father[]" < 10)
            var filters =
                new Dictionary<Type, Func<Type, object, object, int, Func<object, object>>>
                {
                    // Necessary to perform post-processing on the daughters (if any)
                    // of each father we kept in "Father[]" via the 2nd filter below:
                    {
                        typeof(Father), // Note the type
                        (type, obj, key, index) => filteredFatherStreamCallback
                    },
                    // We want to pick only the first 10 fathers from the source:
                    {
                        typeof(Father[]), // Note the type
                        (type, obj, key, index) =>
                            (index < 10) ?
                            filteredFatherStreamCallback :
                            JsonParser.Skip
                    }
                };
            // Read, parse, and deserialize fathers.json.txt in a streamed fashion,
            // and using the above filters, along with the callback we've set up:
            using (var reader = new System.IO.StreamReader(FATHERS_TEST_FILE_PATH))
            {
                FathersData data = parser.Parse<FathersData>(reader, filters);
                System.Diagnostics.Debug.Assert
                (
                    (data != null) &&
                    (data.fathers != null) &&
                    (data.fathers.Length == 10)
                );
                foreach (var father in data.fathers)
                {
                    Console.WriteLine();
                    Console.WriteLine("\t\t{0}'s daughters:", father.name);
                    if ((father.daughters != null) && (father.daughters.Length > 0))
                        foreach (var daughter in father.daughters)
                        {
                            System.Diagnostics.Debug.Assert
                            (
                                !String.IsNullOrEmpty(daughter.maidenName)
                            );
                            Console.WriteLine("\t\t\t\t{0} {1}", daughter.name, daughter.maidenName);
                        }
                    else
                        Console.WriteLine("\t\t\t\t(None)");
                }
            }
            Console.ReadKey();
        }
