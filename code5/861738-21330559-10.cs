        private static void sortAlpphabetical(Student[] studentList)
        {
            for (int i = 1; i < studentList.Length; i++)
            {
                for (int j = 0; j < studentList.Length - 1; j++)
                {
                    string lastName1 = studentList[j].lastName.ToLower() + studentList[j].name.ToLower();
                    string lastName2 = studentList[j + 1].lastName.ToLower() + studentList[j + 1].name.ToLower();
                    int shortestNameLength = Math.Min(lastName1.Length, lastName2.Length);
                    for (int k = 0; k < shortestNameLength; k++)
                    {
                        int c1 = returnIndex(lastName1[k]);
                        int c2 = returnIndex(lastName2[k]);
                        if (c1 == c2)
                        {
                            continue;
                        }
                        if (c1 > c2)
                        {
                            Student currentStudent = studentList[j];
                            studentList[j] = studentList[j + 1];
                            studentList[j + 1] = currentStudent;
                        }
                        break;
                    }
                }
            }
            Console.WriteLine("List of students:\n");
            for (int i = 0; i < studentList.Length; i++)
            {
                Console.WriteLine(string.Format("{0} {1}", studentList[i].name, studentList[i].lastName));
            }
        }
