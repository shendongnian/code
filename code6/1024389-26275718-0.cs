    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication11
    {
        class Program
        {
            static void Main(string[] args)
            {
                var strings = @"<script type='text/javascript'> 
        function initialize() {
            var mapOptions = {
                zoom: 18,
                center: new google.maps.LatLng(0.6213000841833666, 73.46202224493027)
            };  
        } 
    </script>";
                var group =  Regex.Match(strings,"maps.LatLng\\((?<lat>.*?),\\s*(?<long>.*?)\\)",RegexOptions.IgnoreCase).Groups;
                var lat  = group["lat"].Value;
                var lon = group["long"].Value;
            }
        }
    }
