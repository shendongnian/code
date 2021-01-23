    public interface IMyView
    {
        void SetController(MyModelController controller);
        void showDialog();
        Label getLabel1();
        // etc.
    }
    public class MyModelController
    {
        protected IMyView _myView;
        private MyModel _myModel;
        public MyModelController(IMyView view, MyModel mm)
        {
            _myView= view;
            _MyModel = mm;
            view.SetController(this);
        }
        public void myMethod()
        {
          // now i can interact with the view provided my functions are in IMyView
          _myView.showDialog();
          _myView.getLabel1(); // etc.
        }
    }
