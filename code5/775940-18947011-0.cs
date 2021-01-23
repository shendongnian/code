        switch ((ImageTypes)Tab.SelectedIndex)
        {
            case ImageTypes.TypeOne:
                img1.Opacity= 1;
                img2.Opacity = 0.5;
                img3.Opacity  = 0.5;
                break;
            case ImageTypes.TypeTwo:
                img1.Opacity = 0.5;
                img2.Opacity = 1;
                img3.Opacity  = 0.5;
                break;
            case ImageTypes.TypeThree:
                img1.Opacity = 0.5;
                img2.Opacity = 0.5;
                img3.Opacity = 1;
                break;
        }
        public enum ImageTypes
        {
            TypeOne,
            TypeTwo,
            TypeThree
        }
