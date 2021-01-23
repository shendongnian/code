    @if (TempData.ContainsKey(Alerts.SUCCESS))
    {
        foreach (var value in TempData.Values)
        {
            <script>    
                toastr.success("@value.ToString()");
            </script>
            
        }
        TempData.Remove(Alerts.SUCCESS);
          
    }
