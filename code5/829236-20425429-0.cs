    <span>@item.StartDate.ToString("h:mm tt")</span>
    @if (DateTime.Now - StartDate < TimeSpan.FromHours(1))
    {
        <span class="green b">
            New !
        </span>
    }
