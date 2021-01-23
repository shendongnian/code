            using System.Text.Json;
            ...
            var response = await httpClient.GetAsync(url);
            var versionsResponseBytes = await response.Content.ReadAsByteArrayAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var versionsResponse = JsonSerializer.Deserialize<VersionsResponse>(versionsResponseBytes, options);
            var lastVersion = versionsResponse.Versions[^1]; //(length-1)
