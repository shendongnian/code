    public class Class1
    {
        readonly UserBLL bll;
        public Class1(UserBLL bll)
        {
            this.bll = bll;
        }
        public Class1() : this(new UserBLL())
        {
        }
        // ...
