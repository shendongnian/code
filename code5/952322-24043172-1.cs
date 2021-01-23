        public void CatchColor(Color c)
        {
            if (c is BlueColor)
                CatchColor(c as BlueColor);
            if (c is GreenColor)
                CatchColor(c as GreenColor);
        }
?
