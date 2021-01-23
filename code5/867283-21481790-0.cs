        string[] words = { "Alpha", "Beta", "C_word", "D_Word" }; // ....
        string myPhrase = "aBC";
        myPhrase.Replace(" ", string.Empty).ToList().ForEach(a =>
        { 
            int asciiCode = (int)a;
            /// ToUpper()
            int index = asciiCode >= 97 ? asciiCode - 32 : asciiCode;
            Console.WriteLine(words[index - 65]); // ascii --> 65-a , 66-b ...
        });
