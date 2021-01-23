    public class Foo
    {
        private static object _lockKey = new object();
        private void YourEventHandlerMethod(object sender, EventArgs e)
        {   
            lock (_lockKey)
            {
                // the code you put inside this block will be execute only
                // once at time.
                // If a second call has the intention to use this block before
                // the conclusion of the first call, the second call (the thread)
                // will be put in hold.
            }
        }
    }
