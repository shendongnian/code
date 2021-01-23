    public interface IEquipable
    {
        void EquipOn( Player player );
    }
    public class Shield : IEquipable
    {
        public void EquipOn( Player player )
        {
            player.shield = this;
        }
    }
    public class Weapons : IEquipable
    {
        public void EquipOn( Player player )
        {
            player.weapon = this;
        }
    }
