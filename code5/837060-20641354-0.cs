    public enum Identification : ushort
    {
        [LCAttribute("IMG_BG01_Greens")] //Look the type of the attributes is LCAttribute
        BG01_Greens = 0,
        [LCAttribute("Rabbit", "IMG_E01_Rabbit")]
        ENEMY_E01_Rabbit = 2000,
    }
    public static class Enums
    {
        public static LCData GetInfo(Identification id)
        {
            var type = typeof(Identification);
            var memInfo = type.GetMember(id.ToString());
            //this will return an array of LCAttributes
            var attributes = memInfo[0].GetCustomAttributes(typeof(LCAttribute), false);
            //I tell you they are LCAttribute not LCData
            var name = ((LCAttribute)attributes[0]).Name;
            var tex = ((LCAttribute)attributes[0]).Texture;
            //If the above were an LCData why would create a new one here? [Rethorical]
            LCData data;
            data.Name = name;
            data.Texture = tex;
            return data;
        }
    }
