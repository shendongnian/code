    class Student
    {  
        int id;  
        String name;  
        student(int id,String name)
        {  
            this.id = id;  
            this.name = name;  
        }  
        void display()
        {
            Console.WriteLine(id+" "+name);
        }  
        public static void main()
        {  
            Student s1 = new Student(1,"NameA");  
            Student s2 = new Student(2,"NameB");  
            s1.display();  
            s2.display();  
        }  
    }  
