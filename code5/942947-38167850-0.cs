    static void Main(string[] args)
            {
                int min=0;
               
                string[] names = { "Flag", "Nest", "Cup", "Burg", "Yatch", "Next" };
                string name = string.Empty;
                Console.WriteLine("Sorted Strings : ");
    
                for (int i = 0; i < names.Length-1; i++)
                {
                    for (int j = i + 1; j < names.Length;j++ )
                    {
                        
                        if(names[i].Length < names[j].Length)
                               min =names[i].Length;
                        else
                                min =names[j].Length;
                        for(int k=0; k<min;k++)
                        {
                            if (names[i][k] > names[j][k])
                            {
                                name = names[i].ToString();
                                names[i] = names[j];
                                names[j] = name;
                                break;
                            }
                            else if(names[i][k] == names[j][k])
                            {
                                continue;
                            }
                            else
                            {
                                break;
                            }
                
                        }
                    }
                       
    
                }
                for(int i= 0;i<names.Length;i++)
                {
                    Console.WriteLine(names[i]);
                    Console.ReadLine();
                }
            }
        }
