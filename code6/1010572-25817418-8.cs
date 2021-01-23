    function makeValidator(champId, opts) {
        return function (sender, args) {
            // Now this is when it gets harry.
            // Use $get (and $find) inside ASP.NET, especially when
            // dealing with ASP.NET AJAX integration to find a control be ID.
            //
            // HOWEVER, the code uses what appears to be some DevExpress
            // controls and thus must be accessed.. differently, mainly either by
            //   1. `window[clientId]` or
            //   2. `ASPxClientControl.GetControlCollection().GetByName(id);`
            // This is just one of those icky integration things; I've shown usage
            // of the former and it may need to be applied to the other controls as well.
            //
            var reasonControl = window[opts.reasonId];        // DX control
            var dynamicControl = $get(opts.dynamicControlId); // normal ASP.NET/DOM
            var errorImage = window[opts.errorImageId];       // DX control
            if(reasonControl.GetText() != '' || dynamicControl.style.display == "none") {
                // whatever
                dynamicControl.className='';
                errorImage.SetClientVisible(false);
                args.IsValid = true;
            }
            // etc.
        }
    }
