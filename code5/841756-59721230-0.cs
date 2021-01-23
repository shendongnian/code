    @{
        protected void print()
        { 
            @<p>WELCOME!</p>
        }
    
        public async Task OnPostPrint()
        {
            print();
        }
    }
    
    <form asp-page-handler="Print" method="post">
       <button class="btn btn-default">CLICK ME</button>
    </form>
