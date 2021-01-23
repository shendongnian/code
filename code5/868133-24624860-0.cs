                    if (ptrMask[4 * x] == 0)
                    {
                       ptrOutput[4 * x] = 0; // blue
                        ptrOutput[4 * x + 1] = 0; // green
                        ptrOutput[4 * x + 2] = 0; // red
                        //Ensure Transparent
                        ptrOutput[4 * x + 3] = 0; // alpha
                    }
                    else
                    {
                        ptrOutput[4 * x] = ptrInput[4 * x]; // blue
                        ptrOutput[4 * x + 1] = ptrInput[4 * x + 1]; // green
                        ptrOutput[4 * x + 2] = ptrInput[4 * x + 2]; // red
                        //Ensure opaque
                        ptrOutput[4*x + 3] = 255;
 
                    }
