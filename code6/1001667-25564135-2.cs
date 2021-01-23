    namespace Booking.Domain.Model.Geographical
    {
        /// <summary>
        /// The <see cref="IGeocodingService" /> interface.
        /// </summary>
        public interface IGeocodingService
        {
            /// <summary>
            /// Performs a postal code query.
            /// </summary>
            /// <param name="countryIsoCode">The country iso code.</param>
            /// <param name="postalCode">The postal code.</param>
            /// <returns>A geographic coordinate.</returns>
            Coordinate PostalCodeQuery(string countryIsoCode, string postalCode);
        }
    }
