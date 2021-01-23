    public class KeyFrame
    {
        public volatile BitmapImage keyframe;
        public volatile List<string> personsNames;
        public volatile List<string> categories;
        public KeyFrame(BitmapImage keyframe, List<string> personsNames, List<string> categories)
        {
            this.keyframe = keyframe;
            //here we call Freeze funcition on creation to make it modifiable 
            this.keyframe.Freeze();
            this.personsNames = personsNames;
            this.categories = categories;
        }
    }
