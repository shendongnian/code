    public class SelectorPage
    {
        public void CheckType(Type type)
        {
            if (ACheckBox.Exists)
                CheckA(type == Type.A);
            if (BCheckBox.Exists)
                CheckB(type == Type.B);
            if (CCheckBox.Exists)
                CheckC(type == Type.C);
            if (DCheckBox.Exists)
                CheckD(type == Type.D);
            if (ECheckBox.Exists)
                CheckE(type == Type.E);
        }
    }
