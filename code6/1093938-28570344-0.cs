    using System;  
    namespace HaversineFormula  
    {  
    /// <summary>  
    /// The distance type to return the results in.  
    /// </summary>  
    public enum DistanceType { Miles, Kilometers };  
    /// <summary>  
    /// Specifies a Latitude / Longitude point.  
    /// </summary>  
    public struct Position  
    {  
        public double Latitude;  
        public double Longitude;  
    }  
    class Haversine  
    {  
        /// <summary>  
        /// Returns the distance in miles or kilometers of any two  
        /// latitude / longitude points.  
        /// </summary>  
        public double Distance(Position pos1, Position pos2, DistanceType type)  
        {  
            double R = (type == DistanceType.Miles) ? 3960 : 6371;  
            double dLat = this.toRadian(pos2.Latitude - pos1.Latitude);  
            double dLon = this.toRadian(pos2.Longitude - pos1.Longitude);  
            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +  
                Math.Cos(this.toRadian(pos1.Latitude)) * Math.Cos(this.toRadian(pos2.Latitude)) *  
                Math.Sin(dLon / 2) * Math.Sin(dLon / 2);  
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));  
            double d = R * c;  
            return d;  
        }  
        /// <summary>  
        /// Convert to Radians.  
        /// </summary>  
        private double toRadian(double val)  
        {  
            return (Math.PI / 180) * val;  
        }  
    }
