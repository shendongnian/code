        public static class MyClass
    {
            public static string ConvertText(string inputText)
        {
            var newstring = "";
            for (var i = 0; i < inputText.Length; i++)
            {
                if (char.IsUpper(inputText[i]))
                    newstring += " ";
                newstring += inputText[i].ToString(CultureInfo.InvariantCulture);
            } 
            return newstring;
        }
    }
      string output = MyClass.ConvertText("MyNameIsBlaBla");
            Console.WriteLine(output);
