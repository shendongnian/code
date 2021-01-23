            do
            {
                Student newStudent = new Student(); 
                Console.WriteLine("Enter reg. number: ");
                newStudent.regNumber = Console.ReadLine();
                if (newStudent.regNumber.Length != 8)
                {
                    Console.WriteLine("Registration number should has a length of 8 characters");
                }
                else 
                {
                    bool hasE = false; 
                    for(int i = 0 ; i < newStudent.regNumber.Length; i++)
                    {
                        if(newStudent.regNumber[i] == 'E') 
                        {
                            hasE = true;
                            break; 
                        }
                    }
                    if(hasE == true)
                    {
                        Console.WriteLine("Registration number correct :)"); 
                    }
                    else
                    {
                        Console.WriteLine("Registration number does not contain E"); 
                    }
                }
            }
            while(true);
