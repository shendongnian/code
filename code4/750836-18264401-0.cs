    public class TestClassPeterAndCharles : ITestClass
    {
        private readonly ITestClass peter;
        private readonly ITestClass charles;
        public TestClassPeterAndCharles()
        {
            // Create helper objects from base implementation
            // Alternatively, take them as constructor parameters
            this.peter = new TestClassPeter();
            this.charles = new TestClassCharles();
        }
        public string NamePlusLastName(string name)
        {
            // Get the result from each class and operate on them
            string namePeter = this.peter.NamePlusLastName(name);
            string nameCharles = this.charles.NamePlusLastName(name);
            return namePeter + nameCharles;
        }
        public int AgePlus20(int age)
        {
            int agePeter = this.peter.AgePlus20(age);
            int ageCharles = this.charles.AgePlus20(age);
            return agePeter + ageCharles;
        }
        public DateTime YearYouWillDie(int age)
        {
            DateTime yearPeter = this.peter.YearYouWillDie(age);
            DateTime yearCharles = this.charles.YearYouWillDie(age);
            return yearPeter + yearCharles;
        }
    }
