    class MySecondName:ILastName
    {
        public string SecondName()
        {
            return "Michael";
        }
        public string LastName()
        {
            return "Dutt";
        }
    }
    ILastName obj;
    int i = new Random().Next() % 2;
    if (i == 0) obj = new MyName();
    else obj = new MySecondName();
