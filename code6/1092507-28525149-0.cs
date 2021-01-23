    public class Monster
    {
        private const int MIN_X = 156;
        private const int MAX_X = 501;
        private int _x;
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
                if (_x == MIN_X)
                    _toLeft = false;
            }
            else
            {
                _x++;
                if (_x == MAX_X)
                    _toLeft = true;
            }
        }
    }
