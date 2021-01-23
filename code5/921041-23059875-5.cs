using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// included for a theoretical PromptUser commands
using ExampleCompanyLib; 
namespace MyLabeledStatement
{
    class Program
    {
        // as these are constant values, putting here as constants
        // moved from 'x' and 'y' (confusing, since those look like
        // index vars instead of constants anyway, also it frees up
        // 'x' and 'y' to actually use as index vars)
        const int X_BOUND=100;
        const int Y_BOUND=4;
        static void Main(string[] args)
        {
            // conformed var name (MyArray) to standard C# camelCasing
            string[,] myArray = new string[x,y];
            // since this is a very simple init, my personal style is
            // to drop the braces; either is fine; probably better to 
            // stick with keeping them, it does prevent some subtle 
            // bugs from creeping in over time if people aren't used 
            // to doing it this way...
            for (int x=0; x < X_BOUND; ++x)
               for (int y=0; y < Y_BOUND; ++y)
                  myArray[x,y] = y + x*Y_BOUND; 
            // this is assuming ExampleCompanyLib prints a prompt, and then
            // reads from user, validating and forcing a integer input.
            // assumes we have such a lib.
            int userInput=PromptUser("Enter a number to find:", "{i}");
            // assigned to userInput for conformation; (avoids things like
            //   user typing 01 for 1 if inputting a string directly, assuming
            //   our lib has no issues with octal...) but now convert to string
            //   for our comparison below...
            // conformed variable to camelCasing 
            string myNumber=userInput.ToString();
            // we could shortcut things the way they are now by using 
            // that formula; just invert the 'y+x*Y_BOUND' so, 
            // if it's < 1 or > 400 we know it isn't found
            // otherwise, 
            // x=userInput % Y_BOUND
            // y=userInput - (Y_BOUND * x)
            // at least, that should be close, but we're keeping the loop 
            // since it's assumed that it was there to be used for something
            // else...
            // keeping a flag to know if we've found the number
            bool foundIt=false;
            // gonna keep the actual x,y so we can show the user; we could
            // just drop the bool and use whether these are set; but I find
            // this to just be nice and clear, and I see no reason to 
            // optimize away something that tells us exactly what's going on
            int foundX=-1;
            int foundY=-1;
            for (int x=0; x < X_BOUND; ++x)
            {
               for (int y=0; y < Y_BOUND; ++y)
               {
                   // now is a string comparison to be sure will work; not 
                   // sure what result of myArray[x,y].Equals(userInput) is
                   // but it doesn't make much sense to do it that way in C#
                   // even if it were to on the off chance work
                   if (myArray[x,y] == myNumber)
                   { 
                       foundIt=true;
                       foundX=x;
                       foundY=y;
                       // 'breaks out of' the nearest loop, in this case the y for
                       break;
                   }
               }
               // but if we found it, we still need to break here, too
               if (foundIt)
                 break;
           }
           // just giving some info here, treating this as a header, using
           // the pretend lib again:
           PromptNoInput("Number Searched: {0}", myNumber);
           // after it's done, we either found it or didn't, this way we
           // use the flag to tell whether we broke out of the loop due to
           // finding it or just finished all the cells... 
           if (foundIt)
               PromptNoInput(
                   "Found Number '{0}' in Cell &lt;{1},{2}&gt;"
                   ,myNumber,foundX,foundY\
               );
           else
              PromptNoInput(
                   "No Cells Contained Number {0}"
                   ,myNumber
              );
         Console.ReadLine();
        }
    }
}
