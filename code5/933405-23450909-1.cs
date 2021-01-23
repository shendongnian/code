    @using Booking_Ticket_Management_System.Model;
    @model IEnumerable<string>
    
    @{
    ViewBag.Title = "Choose movies";
    } 
    
    <h2>Index</h2>
    <div>
    <ul>
        @foreach(string moviename in @Model)
        {
            <li>
                @moviename
            </li>
        }
    </ul>
    </div>
