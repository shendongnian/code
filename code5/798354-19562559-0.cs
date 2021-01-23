    <div class="product-grid">
            @{                   
                int i = 0;                   
             }
           @foreach (var product in Model.Products)
           {              
               <div class="item-box">
                   @Html.Partial("_ProductBox", product)
               </div>
               i++;  
               double num = (double)i / 4;
               if (System.Math.Ceiling(num) == num && System.Math.Floor(num) == num)
               {
                    <div id="shelf"></div>                                           
               }                                        
            }
            @{
                if(Model.Products.Count % 4 != 0)
                {
                    <div id="shelf"></div>
                }   
            }
        </div>
