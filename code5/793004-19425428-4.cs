    public interface ICrazyThing<U, T> where T : U
    {
        void Get<T>(ref T crazy);
    }
    public class CrazyThing<U, T> : IThing<U, T> where T : U
    {
        private U u;
        public void Get<T>(ref T crazy)
        {
           crazy = this.u;   
        }
    }
