    public class MyButton : Button
    {
        public MyButton(Context c, IAttributeSet a) : base(c,a) 
        {
            Click += (s,e) => {
                if (Command == null) return;
                if (!Command.CanExecute(CommandParameter)) return;
                Command.Execute(CommandParameter);
            };
        }
        public ICommand Command { get;set; }
        public object CommandParameter { get;set; }
    }
