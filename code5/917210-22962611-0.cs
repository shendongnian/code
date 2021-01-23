    public class Facts : IUseFixture<MyFixture>
    {
        void IUseFixture<MyFixture>.SetFixture( MyFixture dummy){}
        [Fact] void T(){}
        [Fact] void T2(){}
    }
    
    class MyFixture
    {
        public MyFixture() 
        {
            // runs once
        }
    }
