     public class Uc<T> : UserControl where T : UserControl
        {
            private List<T> _list;
            public void SetDataSource(List<T> list)
            {
                _list = list;
            }
        }
