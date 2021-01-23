            // Do the sample generation based on formatters only if an action doesn't return an HttpResponseMessage.
            // Here we cannot rely on formatters because we don't know what's in the HttpResponseMessage, it might not even use formatters.
            if (type != null && !typeof(HttpResponseMessage).IsAssignableFrom(type))
            {
                object sampleObject = GetSampleObject(type);
                // Change Begin --------------------------------------
                IEnumerable<MediaTypeFormatter> filteredFormatters = formatters.Where(frmtr => frmtr.GetType() != typeof(JQueryMvcFormUrlEncodedFormatter));
                foreach (var formatter in filteredFormatters)
                {
                // Change End --------------------------------------
