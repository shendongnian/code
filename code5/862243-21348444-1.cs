    interface DisplayMsg
    {
        void ShowMsg();
    }
    /// <summary>
    /// Interface  implemented by Struct
    /// </summary>
    struct StructDisplayMsg : DisplayMsg
    {
        public void ShowMsg()
        {
            Console.WriteLine("Inside struct Showmsg:");
        }
    }
    /// <summary>
    /// Interface implemented by Class
    /// </summary>
    class ObjectDisplayMsg:DisplayMsg
    {
        public int Integer { get; set; }
        public void ShowMsg()
        {
            Console.WriteLine("Inside Object ShowMsg:{0}", Integer);
        }
        /// <summary>
        /// Implicit operator for boxing value type to object
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator ObjectDisplayMsg(int value)
        {
            ObjectDisplayMsg classObject = new ObjectDisplayMsg();
            classObject.Integer = value;
            return classObject;
        }
    }
    private void CheckConcepts()
    {
        StructDisplayMsg localDisplay = new StructDisplayMsg();
        localDisplay.ShowMsg();
        int localInteger = 10;
        /* Boxing of the integer type to  Object */
        ObjectDisplayMsg intobject = (ObjectDisplayMsg)localInteger;
        intobject.ShowMsg();
        Console.ReadKey();
    }
