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
