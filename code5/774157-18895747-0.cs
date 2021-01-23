    // I'm making up the inner types, adapt this to your code
    public abstract class UcetType
    {
        public virtual object predcislo { get; set; }
        public virtual object cislo { get; set; }
        public virtual object kodBanky { get; set; }
        public virtual void WriteToFile(StreamWriter file) 
        { 
            // build the string and write it to the file
            // considering all properties
            // this acts as "default" for this type and all derived ones
        }
    }
    public class StandardniUcetType : UcetType
    {
        // This will use the abstract as-is
        // with all 3 properties and the "default" WriteToFile() method
    }
    public class NestandardniUcetType : UcetType
    {
        /// <summary>
        /// Attempting to use this will throw an exception
        /// </summary>
        public override object predcislo
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
        /// <summary>
        /// Attempting to use this will throw an exception
        /// </summary>
        public override object kodBanky
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }
        // change the way WriteToFile behaves
        public override void WriteToFile(StreamWriter file)
        {
            // build the string and write it to the file
            // only considering 'cislo' property
        }
    }
    // Usage example, based on question
    for (int i = 0; i < dic_vystup.Length; i++)
    {
        RozhraniWSDL.InformaceOPlatciType info = dic_vystup[i];   
        // I assume "3" is the expected length of the array ? Change the for like this:
        for (int x = 0; x <= info.zverejneneUcty.Length; x++)
        {   
            //Delegate to the WriteToFile() method the task to build and write the line!
            info.zverejneneUcty[x].Item.WriteToFile(file2);
        }
    }
