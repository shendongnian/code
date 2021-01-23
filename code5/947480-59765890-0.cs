 csharp
[HttpPost]
public async Task<IActionResult> PostAsync([FromBody] CreateModel createModel)
{
    // Create domain entity and persist
    var entity = await _service.Create(createModel);
    // Return 201
    return new ObjectResult(entity) { StatusCode = StatusCodes.Status201Created };
}
