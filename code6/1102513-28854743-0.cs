            var test = new Test();
            var field = test.GetType().GetField("doc");
            
            field.SetValue(test, new List<Doc>() { new Doc() });
            Console.WriteLine(test.doc.Count); // 1
