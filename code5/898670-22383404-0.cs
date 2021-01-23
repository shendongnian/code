    public class Creature
    {
        private Form form;
    
        public Creature(Form form)
        {
            this.form = form;
        }
    
        ...
    
        public void Left(int speed)
        {
            Graphics grp = form.CreateGraphics();
            ..
            ..
            ..
        }
    }
