    public class date
            {
                private int day;
                private int mounth;
                private int year;
    
                public date(int day, int mounth, int year)
                {
                    this.day = day;
                    this.mounth = mounth;
                    this.year = year;
    
                }
                public void Display()
                {
    
                    Console.WriteLine("{0}/{1}/{2}", day, mounth, year);
    
                }
    
                
            }
    
    public class employee
                {
                    private string name;
                    private date hire_date;
                    private date Emplye_birth;
                    private int number;
    
                    public employee(int number, string name, date bd, date hd)
                    {
                        this.name = name;
                        this.number = number;
                        hire_date = hd;
                        Emplye_birth = bd;
    
                    }
                    public void printEmplyy()
                    {
                        Console.WriteLine("Employee number {0} \n name:{1}", number, name);
                        Console.WriteLine("hire date of {0}", name);
                        hire_date.Display();
                        Console.WriteLine("birthday of {0}", name);
                        Emplye_birth.Display();
    
                    }
                }
