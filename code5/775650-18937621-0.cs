        public interface IMyInterface
        {
            string GetPostName();
        }
        public void PostAction(object actObject)
        {
            var action = actObject as IMyInterface;
            if (action != null)
            {
                var postName = action.GetPostName();
            }
        }
