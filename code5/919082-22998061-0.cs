        public HttpResponseMessage Post(MyViewModel model)
        {
            if (someValidationCheckHere)
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            _myService.Update(Mapper.Map<MyViewModel, MyEntity>(model));
            return new HttpResponseMessage(HttpStatusCode.OK);
        }
