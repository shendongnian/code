    /// <summary>   Values that represent various carriers. </summary>
    [Serializable]
    public enum Carrier
    {
        None = 0,
        Alltel = 1,
        Att = 2,
        BoostMobile = 3,
        Sprint = 4,
        Tmobile = 5,
        UsCellular = 6,
        Verizon = 7,
        VirginMobile = 8
    }
    /// <summary>   Carrier extensions. </summary>
    public static class CarrierExtensions
    {
        /// <summary>   Gets the email to SMS gateway for the specified carrier. </summary>
        /// <param name="carrier">  The carrier to get the gateway for.</param>
        /// <returns>   The email to SMS gateway. </returns>
        public static String GetGateway(this Carrier carrier)
        {
            switch (carrier)
            {
                case Carrier.Alltel:
                    return "@message.alltel.com";
                case Carrier.Att:
                    return "@txt.att.net";
                case Carrier.BoostMobile:
                    return "@myboostmobile.com";
                case Carrier.Sprint:
                    return "@messaging.sprintpcs.com";
                case Carrier.Tmobile:
                    return "@tmomail.net";
                case Carrier.UsCellular:
                    return "@email.uscc.net";
                case Carrier.Verizon:
                    return "@vtext.com";
                case Carrier.VirginMobile:
                    return "@vmobl.com";
            }
            return String.Empty;
        }
        /// <summary>   Formats the phone number with the appropriate email to SMS gateway. </summary>
        /// <param name="carrier">      The carrier to get the gateway for.</param>
        /// <param name="phoneNumber">  The phone number.</param>
        /// <returns>   The formatted phone number. </returns>
        public static String FormatPhoneNumber(this Carrier carrier, String phoneNumber)
        {
            return String.Format("{0}{1}", phoneNumber, carrier.GetGateway());
        }
    }
