    public class Monster
    {
        private const int MIN_X = 156;
        private const int MAX_X = 501;
        private int _x;
        
        //your TL(probably) will tell you to use Enum 
        private bool _toLeft;
        public Monster()
        {
            _toLeft = false;
            _x = MIN_X;
        }
        public void Move()
        {
            if (_toLeft)
            {
                _x--;
            }
            else
            {
                _x++;
            }
            CheckEdges();
        }
        private void CheckEdges()
        {
            if (_x == MAX_X || _x == MIN_X)
                _toLeft = !_toLeft;
        }
    }
