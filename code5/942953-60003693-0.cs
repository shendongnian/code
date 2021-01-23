                string[] names = { "Flag", "Nest", "Cup", "Burg", "Yatch", "Next" };
                string temp = "";
                int tempX = 0, tempY = 0;
                int tempX1 = 0, tempY1 = 0;
                for (int i = 0; i<names.Length; i++)
                {
                    for (int j = i+1; j<names.Length; j++)
                    {
                        if (((string)names[i])[0] > ((string)names[j])[0])
                        {
                            temp=(string)names[i];
                            names[i]=names[j];
                            names[j]=temp;
                        }
                        else if (((string)names[i])[0] == ((string)names[j])[0])
                        {
                            tempX=0; tempY=0;
                            tempX1=names[i].Length;
                            tempY1=names[j].Length;
                            while (tempX1 > 0 && tempY1 >0)
                            {
                                if (((string)names[i])[tempX] !=((string)names[j])[tempY])
                                {
                                    if (((string)names[i])[tempX]>((string)names[j])[tempY])
                                    {
                                        temp=(string)names[i];
                                        names[i]=names[j];
                                        names[j]=temp;
                                        break;
                                    }
                                }
                                tempX++;
                                tempY++;
                                tempX1--;
                                tempY1--;
                            }
                        }
                    }
                }
