    namespace Playground2014.ConsoleStuff
    {
        using System;
    
        internal static class Program
        {
            static void Main()
            {
                const int MaskForCommentOne = 1;
                const int MaskForCommentTwo = 2;
                const int MaskForCommentThree = 4;
                const int MaskForCommentFour = 8;
                const int MaskForCommentFive = 16;
                const int MaskForCommentSix = 32;
                const int MaskForCommentSeven = 64;
                const int MaskForCommentEight = 128;
    
                int myCommentNumber = 72;
                Console.WriteLine("My input number is: {0}", myCommentNumber);
                if(MaskForCommentOne == (myCommentNumber & MaskForCommentOne))
                {
                    Console.WriteLine("Comment One");
                }
    
                if(MaskForCommentTwo == (myCommentNumber & MaskForCommentTwo))
                {
                    Console.WriteLine("Comment Two");
                }
    
                if(MaskForCommentThree == (myCommentNumber & MaskForCommentThree))
                {
                    Console.WriteLine("Comment Three");
                }
    
                if(MaskForCommentFour == (myCommentNumber & MaskForCommentFour))
                {
                    Console.WriteLine("Comment Four");
                }
    
                if(MaskForCommentFive == (myCommentNumber & MaskForCommentFive))
                {
                    Console.WriteLine("Comment Five");
                }
    
                if(MaskForCommentSix == (myCommentNumber & MaskForCommentSix))
                {
                    Console.WriteLine("Comment Six");
                }
    
                if(MaskForCommentSeven == (myCommentNumber & MaskForCommentSeven))
                {
                    Console.WriteLine("Comment Seven");
                }
    
                if(MaskForCommentEight == (myCommentNumber & MaskForCommentEight))
                {
                    Console.WriteLine("Comment Eight");
                }
            }
        }
    }
