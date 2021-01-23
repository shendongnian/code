    var val = "Hello World!";
    unsafe
    {
        fixed (char* src = val)
        {
            var ptr = (int*)src;
            //explicit definition of what val.Length / 2 would actually mean
            // -> there are actually 6 integers here but 12 chars
            var len = val.Length * sizeof(char) / sizeof(int);  
            while (len > 0)
            {
                //char pointer to the first "char" of the int
                var word = (char*) ptr;         
                Console.WriteLine(*word);
                /* types matter here.  ptr[1] is the next _integer_ 
                   not the next character like it would for a char* */
                Console.WriteLine(word[1]);   //next char of the int @ ptr
                ptr++; // next integer / word[2]
                len--;
            }
        }
    }
