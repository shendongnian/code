    public struct Test
    {
        public int x;
        public int y;
        [Pure]
        public static bool AreEqual(Test lhs, Test rhs)
        {
            Contract.Ensures(Contract.Result<bool>() == ((lhs.x == rhs.x) && (lhs.y == rhs.y)));
            return (lhs.x == rhs.x) && (lhs.y == rhs.y);
        }
        [Pure]
        public static bool AreNotEqual(Test lhs, Test rhs)
        {
            Contract.Ensures(Contract.Result<bool>() == !AreEqual(lhs, rhs));
            return !AreEqual(lhs, rhs);
        }
    }
    // CodeContracts: Checked 4 assertions: 4 correct
