    public class ViewModelMain
    {
        public MyPage p { get; set; }
        public ViewModelMain()
        {
            p = new MyPage(new ModelPage() { NbrLine = 5, NbrCapsLock = 1 });
        }
    }
