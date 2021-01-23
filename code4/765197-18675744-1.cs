    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Number of Layers ? ");
                int input0 = 0;
                bool right0 = int.TryParse(Console.ReadLine(), out input0);
                if (right0 && input0 > 0)
                {
                    int tot_layers = input0;
                    int[] maxDiamLayer = new int[tot_layers + 1]; //better maintain the indexing as displayed to the user: starting from 1
                    bool[] layerDone = new bool[tot_layers + 1]; //This boolean array will make sure that you don't use the same layer more than once
                    int disk_number = 0;
                    for (int i = 1; i <= tot_layers; i++)
                    {
                        Console.Write("\nIntroduce the maximum diameter for the layer num {0} : ", i);
                        maxDiamLayer[i] = int.Parse(Console.ReadLine());
                    }
    
                    Console.Write("\nPress 1 to Insert disk? ");
                    input0 = 0;
                    right0 = int.TryParse(Console.ReadLine(), out input0);
    
                    while (right0 && input0 == 1)
                    {
    
                        Console.Write("\nDiameter of Disk? ");
                        int input = 0;
                        bool right = int.TryParse(Console.ReadLine(), out input);
                        if (!right || input <= 0)
                        {
                            Console.Write("\nWrong Diameter. ");
                            continue;
                        }
                        int disk_diameter = input;
    
                        bool oneInserted = false;
                        for (int i = 1; i <= tot_layers; i++)
                        {
                            if (disk_diameter <= maxDiamLayer[i] && !layerDone[i])
                            {
                                layerDone[i] = true;
                                oneInserted = true;
                                disk_number++;
                                Console.Write("\nNumber of disks contained in container are : {0}", disk_number);
                                Console.Write("\nPress 1 to Insert more disk(s)? ");
                                int input2 = 0;
                                bool right2 = int.TryParse(Console.ReadLine(), out input2);
                                if (!right2 || input2 != 1 || disk_number >= tot_layers) break;
    
                                Console.Write("\nDiameter of Disk? ");
                                input = 0;
                                right = int.TryParse(Console.ReadLine(), out input);
                                if (!right || input <= 0)
                                {
                                    Console.Write("\nWrong Diameter. ");
                                    break;
                                }
                                disk_diameter = input;
                            }
                        }
    
                        if (disk_number >= tot_layers)
                        {
                            Console.Write("\nAll the layers are filled");
                            break;
                        }
                        else
                        {
                            Console.Write("\nWrong diameter. Try again.");
                        }
    
                        if (!oneInserted)
                        {
                            Console.Write("\nThe disk couldn't be inserted");
                            Console.Write("\nPress 1 to continue ");
                            int input3 = 0;
                            bool right3 = int.TryParse(Console.ReadLine(), out input3);
                            if (!right3 || input3 != 1) break;
                        }
                    }
                }
    
                Console.ReadLine(); 
    
            }
   
        }
    }
