    class student
    {  
        int id;  
        String name;  
          
        student(int id,String name)
        {  
            id = id;  
            name = name;  
        }  
        void display()
        {
            Console.WriteLine(id+" "+name);
        }  
        public static void main()
        {  
            student s1 = new student(1,"NameA");  
            student s2 = new student(2,"NameB");  
            s1.display();  
            s2.display();  
        }  
    }  
