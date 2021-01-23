            // Validate
            Validate<List<User>>(user);
            if (!ModelState.IsValid)
            {
                return new InvalidModelStateResult(ModelState, true, new DefaultContentNegotiator(), Request, new MediaTypeFormatter[] { new JsonMediaTypeFormatter() }); // Force JSON
            }
