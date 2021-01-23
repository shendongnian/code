    namespace Booking.Adapter.CloudMade
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Net.Http;
        using System.Text;
        using System.Threading.Tasks;
        using Booking.Domain.Model.Geographical;
        /// <summary>
        /// The <see cref="CloudMadeAdapter" /> class.
        /// </summary>
        public class CloudMadeGeocodingService : IGeocodingService
        {
            /// <summary>
            /// Performs a postal code query.
            /// </summary>
            /// <param name="countryIsoCode">The country iso code.</param>
            /// <param name="postalCode">The postal code.</param>
            /// <returns>
            /// A geographic coordinate.
            /// </returns>
            public Coordinate PostalCodeQuery(string countryIsoCode, string postalCode)
            {
                string country;
                switch (countryIsoCode)
                {
                    case "GB":
                        country = "UK";
                        break;
                    default:
                        country = null;
                        break;
                }
                if (country == null)
                {
                    return null;
                }
                using (HttpClient httpClient = new HttpClient())
                {
                    // TODO: Make call to CloudMade v2 geocoding API.
                }
                // TODO: Remove this.
                return null;
            }
        }
    }
