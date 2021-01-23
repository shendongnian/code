    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel;
    namespace common
    {
    public static class EnumHelper
    {
            
        public enum Speed  //example
        {
            [Description("5 metters per second")]
            Five = 5,
            [Description("10 metters per second")]
            Ten = 10,
            [Description("15 metters per second")]
            Fifteen = 15,
            [Description("20 metters per second")]
            Twenty = 20,
            //[Description("25 metters per second")]
            TwentyFive = 25,
           [Description("30 metters per second")]
            Thirty = 30
        }
        /// <summary>
        /// get the string value of Enum Attribute
        /// </summary>
        /// <param name="EnumConstant"></param>
        /// <returns>
        /// string enumDesctiption = EnumHelper.EnumDescription(EnumHelper.Speed.Thirty);
        ///  enumDesctiption = EnumHelper.EnumDescription(DayOfWeek.Monday); when there is no desc returns as string the ENUM property
        /// </returns>
        public static string EnumDescription(Enum EnumConstant)
        {
            System.Reflection.FieldInfo fi = EnumConstant.GetType().GetField(EnumConstant.ToString());
            DescriptionAttribute[] aattr = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (aattr.Length > 0)
            {
              return aattr[0].Description;
            }
            else
            {
                return EnumConstant.ToString();
            }
        }
       }
    }
