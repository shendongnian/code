       //using (System.IO.StreamWriter writer = new System.IO.StreamWriter("NEW.txt"))
       //     {
       //         System.Console.SetOut(writer);
       //         System.Console.WriteLine("Hello text file");
       //         System.Console.WriteLine("I'm writing to you from visual C#");
       //     }
       //This following part only works when the previous block is commented it out
        using (System.IO.StreamReader reader = new System.IO.StreamReader("NEW.txt"))
        {
            string content = reader.ReadToEnd();
            Console.WriteLine(content);
        }
