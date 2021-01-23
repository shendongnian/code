        public interface IGameEntity
        {
            void OnClick();
            bool CollidesWith(Vector2 pos);
            void Do();
        }
    
        public abstract class Actor: IGameEntity
        {
            public int _speed;
            public TileSprite _UI;
    
            public virtual bool CollidesWith(Vector2 pos)
            {
                //Do stuff here
            }
    
            // can be marked virtual with implementation if you want a default
            // this way base classes will be forced to implement their own implementation
            public abstract void OnClick();
    
            // can be marked virtual with implementation if you want a default
            // this way base classes will be forced to implement their own implementation
            public abstract void Do();
        }
    
        public class Policeman: Actor
        {
            public Policeman()
            {
                _speed = 10;
            }
    
            public override void OnClick()
            {
                //Do stuff
            }
    
            public override void Do()
            {
                //Do Acting for Police
            }
        }
    
        public abstract class Building: IGameEntity
        {
            public TileSprite _UI;
    
            public bool CollidesWith(Vector2 pos)
            {
                //Do stuff here
            }
    
            public abstract void OnClick();
    
            public abstract void Do();
        }
    
        public class PoliceStation: Building
        {
            public PoliceStation()
            {
    
            }
    
            public override void OnClick()
            {
                //Do stuff
            }
    
            public override void Do()
            {
                // Do Building
            }
        }
