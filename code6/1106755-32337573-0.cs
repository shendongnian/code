    class MyGRBCallback : GRBCallback
    {
        protected override void Callback()
        {
            if (this.where == GRB.Callback.MESSAGE)
            {
                String text = this.GetStringInfo(GRB.Callback.MSG_STRING);
                Debug.WriteLine(text);
            }
        }
    }
