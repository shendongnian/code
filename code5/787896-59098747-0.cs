    public async Task<ActionResult<IEnumerable<Numbers>>> GetAll([BindRequired, FromQuery]string[] numbers)
            {
                var result = await _service.GetAllDetails(numbers);
                return Ok(result);
            }
