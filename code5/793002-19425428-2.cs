    public interface ICrazyThing<U, T> where T : U
    {
        void Get<T>(ref T crazy);
    }
    public class CrazyThing<U, T> : IThing<U, T> where T : U
    {
        public void Get<T>(ref T crazy)
        {
           crazy = this.u;   
        }
    }
