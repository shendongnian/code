    public interface ITestClass
    {
    
        [ChoosePerson]               
        string NamePlusLastName(string name);
    
        [ChoosePerson]   
        int AgePlus20(int age);
    
        DateTime YearYouWillDie(int age);
    }
