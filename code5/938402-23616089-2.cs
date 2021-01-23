    <ul id="movieEditor" style="list-style-type: none">
       @if(Model.UserandMovieViewModel.cinema.Any())
       {
           foreach (CinemaViewModel cinemamodel in Model.UserandMovieViewModel.cinema) {
             Html.RenderPartial("MovieEntryEditor", cinemamodel);
            }
       }
       else
       {
           @{ Html.RenderPartial("MovieEntryEditor", new CinemaViewModel()) };
       }
     </ul>
     <a id="addAnother" href="#">Add another</a>
