     public interface IGameEntity
        {
            bool CollidesWith();
            void OnClick();
            void DoActing();
        }
      public class Actor : IGameEntity { //Interface implemented }
      public class Building: IGameEntity { //Interface implemented }
      public class Policeman: IGameEntity { //Interface implemented }
      public class Fireman: IGameEntity { //Interface implemented }
      public class FireStation: IGameEntity { //Interface implemented }
